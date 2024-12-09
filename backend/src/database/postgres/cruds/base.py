from typing import Type, Any, Mapping, Sequence
from uuid import UUID

from sqlalchemy import delete, update, select, ScalarResult
from sqlalchemy.ext.asyncio import async_sessionmaker as AsyncSessionMaker
from sqlalchemy.ext.asyncio import AsyncSession
from src.database.postgres.models import Base


class BasePostgresCRUD[Model: Base]:
    _async_session_maker: AsyncSessionMaker | None = None
    _model: Type[Model] | None = None

    @property
    def async_session_maker(self) -> AsyncSessionMaker:
        if self._async_session_maker is None:
            raise ValueError(f'_async_session_maker is not initialized')
        return self._async_session_maker

    @async_session_maker.setter
    def async_session_maker(self, value: AsyncSessionMaker) -> None:
        if not isinstance(value, AsyncSessionMaker):
            raise ValueError(f'_async_session_maker requires async_session_maker instance. Got {value}')
        self._async_session_maker = value

    async def get_one_or_none_by_id(self, _id: int | str | UUID) -> Model | None:
        async with self.async_session_maker() as session:
            query = select(self._model).where(self._model.id == _id)
            result = await session.execute(query)
            return result.scalar_one_or_none()

    async def get_one_by_id(self, _id: int) -> Model:
        async with self.async_session_maker() as session:
            query = select(self._model).where(self._model.id == _id)
            result = await session.execute(query)
            return result.scalar_one()

    async def get_all(self) -> ScalarResult:
        async with self.async_session_maker() as session:
            query = select(self._model)
            result = await session.execute(query)
            return result.scalars()

    async def create_object(self, data: Mapping[str, Any]) -> Model:
        async with self.async_session_maker() as session:
            new_db_item = self._model(**data)
            session.add(new_db_item)
            await session.commit()
            await session.refresh(new_db_item)
            return new_db_item

    async def create_objects(self, data: Sequence[Mapping[str, Any]]) -> None:
        async with self.async_session_maker() as session:
            new_db_items = [self._model(**item) for item in data]
            session.add_all(new_db_items)
            await session.commit()

    async def update_object_by_id(self, _id: int | str | UUID, data: Mapping[str, Any]) -> None:
        async with self.async_session_maker() as session:
            stmp = update(self._model).where(self._model.id == _id).values(data)
            await session.execute(stmp)
            await session.commit()

    async def delete_object_by_id(self, _id: int | str | UUID) -> None:
        async with self.async_session_maker() as session:
            stmp = delete(self._model).where(self._model.id == _id)
            await session.execute(stmp)
            await session.commit()

    async def delete_objects_by_ids(self, _ids: Sequence[int | str | UUID]) -> None:
        async with self.async_session_maker() as session:
            stmp = delete(self._model).where(self._model.id.in_(_ids))
            await session.execute(stmp)
            await session.commit()









