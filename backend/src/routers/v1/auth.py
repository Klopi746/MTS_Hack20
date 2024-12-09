from fastapi import APIRouter, Depends
from fastapi.security import OAuth2PasswordRequestForm

from src.schemas.auth import TokenData
from src.schemas.users import UserCreate

router = APIRouter(
    prefix="/auth",
)


@router.post('/register')
async def register_user(user_data: UserCreate):
    pass


@router.post('/token', response_model=TokenData)
async def authorized_user(form_data: OAuth2PasswordRequestForm = Depends()):
    pass
