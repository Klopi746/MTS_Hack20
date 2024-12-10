from pydantic import Field, computed_field
from pydantic_settings import BaseSettings, SettingsConfigDict


class BackendConfig(BaseSettings):
    application: str
    mode: str = Field(default='dev')

    model_config = SettingsConfigDict(env_prefix='BACKEND_', extra="allow")

    @computed_field
    @property
    def is_dev(self) -> bool:
        return self.mode.lower() == "dev"

    @computed_field
    @property
    def is_prod(self) -> bool:
        return self.mode.lower() == "prod"


class PostgresConfig(BaseSettings):
    user: str
    password: str
    db: str
    host: str
    port: int

    @computed_field
    @property
    def db_url(self) -> str:
        return f'postgresql+asyncpg://{self.user}:{self.password}@{self.host}:{self.port}/{self.db}'

    model_config = SettingsConfigDict(env_prefix='POSTGRES_', extra="allow")


class RedisConfig(BaseSettings):
    pass


class MongoConfig(BaseSettings):
    driver: str
    host: str
    port: int | None = Field(default=None)
    db_name: str

    @computed_field
    @property
    def db_url(self) -> str:
        return f'{self.driver}://{self.host}:{self.port}/'

    model_config = SettingsConfigDict(env_prefix='MONGO_', extra="allow")


app_config = BackendConfig(_env_file='../.env')

postgres_config = PostgresConfig(_env_file='../.env')

# redis_config = RedisConfig()
#
mongo_config = MongoConfig()

print(mongo_config.db_url)