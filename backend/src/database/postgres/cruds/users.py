from typing import Type

from sqlalchemy import select

from src.database.postgres.cruds.base import BasePostgresCRUD
from src.database.postgres.models import User


class UsersCRUD(BasePostgresCRUD):
    _model = User

    async def get_by_email(self, email: str) -> _model:
        async with self.async_session_maker() as session:
            query = select(self._model).where(User.email == email)
            result = await session.execute(query)
            return result.scalar_one()

