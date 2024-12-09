from uuid import UUID
from sqlalchemy.orm import declarative_base, Mapped, mapped_column, DeclarativeBase


class Base(DeclarativeBase):
    id: Mapped[UUID] = mapped_column(primary_key=True, index=True, unique=True)


class User(Base):
    __tablename__ = 'users'

    email: Mapped[str] = mapped_column(unique=True, index=True)
    hashed_password: Mapped[str]

    def __repr__(self) -> str:
        return f'<{self.__name__} id={self.id}>'
