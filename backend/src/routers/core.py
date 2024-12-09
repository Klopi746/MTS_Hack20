from fastapi import APIRouter

router = APIRouter(
    tags=['Core']
)


@router.get('/healthcheck')
async def core_healthcheck():
    return {'status': 'ok'}

