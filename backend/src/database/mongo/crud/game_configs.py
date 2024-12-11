from typing import Sequence

from bson import ObjectId

from src.database.mongo.crud.base import BaseMongoCRUD


class GameConfigsDRUD(BaseMongoCRUD):

    async def get_active(self, game_type: str) -> Sequence[dict]:
        game_configs = self.collection.find({'game_type': game_type, 'active': True})
        return await game_configs.to_list()

    async def set_active(self, _id: str):
        result = await self.collection.update_one({'_id': ObjectId(_id)}, {'$set': {'active': True}})

        config = await self.collection.find_one({'_id': ObjectId(_id)})

        if not config:
            raise

        await self.collection.update_many({'_id': {'$ne': ObjectId(_id)}, 'game_type': config['game_type']}, {'$set': {'active': False}})


