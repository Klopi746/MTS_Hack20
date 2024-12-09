import uuid

from fastapi import APIRouter
from src.schemas.users import UserOut, UserChange

router = APIRouter(
    prefix="/users",
    tags=["Пользователи"],
)


@router.get('', response_model=list[UserOut])
async def get_users_list():
    pass


@router.get('/{user_id}', response_model=UserOut)
async def get_user_by_id(user_id: uuid.UUID):
    pass


@router.patch('/{user_id}')
async def get_user_by_id(data: UserChange):
    pass


@router.delete('/{user_id}')
async def delete_user_by_id(user_id: uuid.UUID):
    pass

