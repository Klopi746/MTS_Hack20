from sqlalchemy import text
from sqlalchemy.ext.asyncio import create_async_engine, async_sessionmaker, AsyncSession, AsyncEngine
from backend.src.database.postgres.cruds.base import BasePostgresCRUD
from src.shared.configs import postgres_config as config
from sqlalchemy.exc import SQLAlchemyError


class PostgresContext[PostgresCRUD: BasePostgresCRUD]:
    """ Класс для работы с СУБД PostgreSQL """

    #: CRUD для взаимодействия с таблицей
    _crud: PostgresCRUD | None = None

    engine = create_async_engine(
        config.db_url,
        future=True,
        echo=False,
        pool_pre_ping=True
    )

    async_session = async_sessionmaker(
        engine,
        expire_on_commit=False,
        class_=AsyncSession
    )

    def __init__(
            self,
            crud: PostgresCRUD | None = None,
            engine: AsyncEngine | None = None,
    ):
        if engine:
            self.engine = engine
            self.async_session = async_sessionmaker(
                engine,
                expire_on_commit=False,
                class_=AsyncSession
            )
        if crud:
            self._crud = crud
            self._crud.async_session_maker = self.async_session

    @property
    def crud(self) -> PostgresCRUD:
        if self._crud:
            return self._crud
        else:
            raise ValueError('CRUD object has not been initialized')

    @crud.setter
    def crud(self, crud: PostgresCRUD):
        self._crud = crud
        self._crud.async_session = self.async_session

    @classmethod
    async def check_connection(cls):
        async with cls.async_session() as session:
            try:
                # Execute a simple query
                await session.execute(text("SELECT 1"))
                print("Database connection is successful.")
            except SQLAlchemyError as e:
                print(f"Database connection failed: {e}")
                raise




