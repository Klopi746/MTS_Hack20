from contextlib import asynccontextmanager
from fastapi import FastAPI
from starlette.middleware.cors import CORSMiddleware

from src.database.postgres.context import PostgresContext
from src.routers.v1 import router as v1_router
from src.routers.core import router as core_router
from src.shared.configs import app_config


@asynccontextmanager
async def lifespan(app: FastAPI):
    await PostgresContext.check_connection()
    yield


app = FastAPI(title=app_config.application, lifespan=lifespan, root_path="/api", debug=app_config.is_dev)
app.add_middleware(
    CORSMiddleware,
    allow_origins=['*'],
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)

app.include_router(core_router)
app.include_router(v1_router)

