from fastapi import APIRouter

router = APIRouter(
    prefix='/configs'
)


@router.get('')
async def get_configs_list():
    pass


@router.get('/{config_id}')
async def get_config(config_id: int):
    pass


@router.delete('/{config_id}')
async def delete_config(config_id: int):
    pass


@router.patch('/{config_id}')
async def update_config(config_id: int):
    pass