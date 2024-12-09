from uuid import UUID

from pydantic import BaseModel, EmailStr


class UserOut(BaseModel):
    id: UUID
    email: str


class FullUserOut(UserOut):
    hashed_password: str


class UserCreate(BaseModel):
    email: EmailStr
    password: str


class UserChange(BaseModel):
    pass

