from fastapi import APIRouter
from src.routers.v1.games.configurations import router as configs_router

router = APIRouter(
    prefix='/games'
)

router.include_router(configs_router)