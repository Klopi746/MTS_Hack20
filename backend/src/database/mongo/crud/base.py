from abc import ABC, abstractmethod
from typing import Sequence

from motor.motor_asyncio import AsyncIOMotorDatabase


class BaseMongoCRUD(ABC):
    collection_name: str
    db: AsyncIOMotorDatabase | None = None

    @abstractmethod
    def get_object_by_id(self):
        ...

    @abstractmethod
    def get_objects_by_ids(self, ids: Sequence[int]):
        ...

    @abstractmethod
    def create_object(self, obj: dict) -> None:
        ...
