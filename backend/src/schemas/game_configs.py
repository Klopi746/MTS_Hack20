from datetime import datetime
from typing import Any
from pydantic import BaseModel, Field
from typing import Mapping

from pydantic_mongo import PydanticObjectId


class GameConfigCreate(BaseModel):
    title: str
    game_type: str
    active: bool = False
    configuration: Mapping[str, Any]
    created_at: datetime = Field(default_factory=datetime.now)
    updated_at: datetime = Field(default_factory=datetime.now)


class GameConfigOut(GameConfigCreate):
    id: PydanticObjectId = Field(validation_alias='_id')


class GameConfigUpdate(BaseModel):
    title: str
    configuration: Mapping[str, Any]
    active: bool



