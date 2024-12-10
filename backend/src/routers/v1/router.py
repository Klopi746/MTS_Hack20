from fastapi import APIRouter
from .users import router as users_router
from .games import router as gams_router
from .files import router as files_router

router = APIRouter(
    prefix="/v1",
)

router.include_router(users_router)
router.include_router(gams_router)
router.include_router(files_router)

