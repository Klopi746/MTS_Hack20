from pymongo.errors import ConnectionFailure
from motor.motor_asyncio import AsyncIOMotorClient, AsyncIOMotorDatabase

from src.database.mongo.crud.base import BaseMongoCRUD
from src.shared.configs import mongo_config as config


class MongoContext[MongoCRUD: BaseMongoCRUD]:
    """ Класс для работы с СУБД MongoDB """

    #: CRUD для взаимодействия с таблицей
    _crud: MongoCRUD | None = None

    #: Клиент СУБД
    client: AsyncIOMotorClient = AsyncIOMotorClient(config.db_url)

    #: База данных
    db: AsyncIOMotorDatabase

    @property
    def crud(self) -> MongoCRUD:
        if self._crud:
            return self._crud
        else:
            raise ValueError('CRUD object has not been initialized')

    @crud.setter
    def crud(self, crud: MongoCRUD):
        self._crud = crud
        self._crud.db = self.db

    @classmethod
    async def check_connection(cls):
        try:
            await cls.client.admin.command('ping')
        except Exception as e:
            raise ConnectionFailure("Connection to MongoDB failed!")

    def __init__(self, *,
                 client: AsyncIOMotorClient | None = None,
                 db_name: str = config.db_name,
                 crud: MongoCRUD | None = None,
                 ):
        if client:
            self.client = client

        self.db: AsyncIOMotorDatabase = self.client[db_name]

        if crud:
            self._crud = crud
            self._crud.db = self.db
