from typing import Mapping, Any, Sequence

from src.database.mongo.context import MongoContext
from src.database.mongo.crud.game_configs import GameConfigsDRUD
from src.schemas.game_configs import GameConfigOut, GameConfigCreate, GameConfigUpdate


class GameConfigsRepository:
    mongo_context = MongoContext[GameConfigsDRUD](crud=GameConfigsDRUD())

    async def get_all(self) -> Sequence[GameConfigOut]:
        configs = await self.mongo_context.crud.get_objects_list()
        return [GameConfigOut(**i) for i in configs]

    async def get_by_id(self, _id: int) -> GameConfigOut | None:
        return await self.mongo_context.crud.get_object_by_id(_id=_id)

    async def create_config(self, data: GameConfigCreate) -> Mapping[str, Any]:
        result = await self.mongo_context.crud.create_object(data.model_dump())
        return {'_id': str(result)}

    async def delete_by_id(self, _id: str) -> None:
        await self.mongo_context.crud.delete_object_by_id(_id)

    async def update_by_id(self, _id: str, data: GameConfigUpdate) -> None:
        await self.mongo_context.crud.update_object_by_id(_id, data.model_dump())

    async def mark_as_active(self, _id: str) -> None:
        await self.mongo_context.crud.set_active(_id=_id)

    async def get_active(self, game_type: str) -> GameConfigOut:
        configs = await self.mongo_context.crud.get_active(game_type)





