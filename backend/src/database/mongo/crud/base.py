from abc import ABC, abstractmethod
from typing import Sequence, Mapping, Any

from bson import ObjectId
from motor.motor_asyncio import AsyncIOMotorDatabase, AsyncIOMotorCollection


class BaseMongoCRUD(ABC):
    collection_name: str = "game_configs"
    db: AsyncIOMotorDatabase | None = None

    @property
    def collection(self) -> AsyncIOMotorCollection:
        if self.db is None:
            raise ValueError("Database is empty")
        else:
            return self.db[self.collection_name]

    async def get_object_by_id(self, _id: str) -> Mapping[str, Any] | None:
        return await self.collection.find_one({'_id': ObjectId(_id)})

    async def get_objects_by_ids(self, ids: Sequence[int]):
        pass

    async def delete_object_by_id(self, _id: str):
        result = await self.collection.delete_one({'_id': ObjectId(_id)})
        return result

    async def create_object(self, obj: Mapping[str, Any]) -> ObjectId:
        result = await self.collection.insert_one(obj)
        return result.inserted_id

    async def get_objects_list(self, *args, **kwargs) -> Sequence[Mapping[str, Any]]:
        objects = self.collection.find()
        return await objects.to_list()

    async def update_object_by_id(self, _id: str, values: Mapping[str, Any], *args, **kwargs) -> None:
        result = await self.collection.update_one(
            filter={'_id': ObjectId(_id)},
            update={'$set': values}
        )

