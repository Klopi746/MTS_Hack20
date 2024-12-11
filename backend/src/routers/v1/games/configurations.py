from fastapi import HTTPException

import bson
from fastapi import APIRouter
from starlette import status

from src.repositories.game_configs import GameConfigsRepository
from src.schemas.game_configs import GameConfigCreate, GameConfigOut, GameConfigUpdate

router = APIRouter(
    prefix='/configs'
)


@router.get('', response_model=list[GameConfigOut])
async def get_configs_list():
    return await GameConfigsRepository().get_all()


@router.post('')
async def create_config(game_config: GameConfigCreate):
    return await GameConfigsRepository().create_config(game_config)


@router.get('/{config_id}', response_model=GameConfigOut)
async def get_config(config_id: str):
    try:
        game_config = await GameConfigsRepository().get_by_id(config_id)
    except bson.errors.InvalidId as e:
        raise HTTPException(status.HTTP_400_BAD_REQUEST, f'Invalid game config id: {e}')

    if not game_config:
        raise HTTPException(status.HTTP_404_NOT_FOUND, f'Game config with id={config_id} not found')

    return game_config


@router.delete('/{config_id}')
async def delete_config(config_id: int):
    await GameConfigsRepository().create_config(config_id)


@router.patch('/{config_id}')
async def update_config(config_id: str, data: GameConfigUpdate):
    await GameConfigsRepository().update_by_id(_id=config_id, data=data)


@router.post('/{config_id}/make-active')
async def make_config_active(config_id: str):
    await GameConfigsRepository().mark_as_active(_id=config_id)


