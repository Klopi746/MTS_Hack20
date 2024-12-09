from uuid import UUID

from pydantic import BaseModel


class TokenData(BaseModel):
    access_token: str
    refresh_token: str
    user_id: UUID

