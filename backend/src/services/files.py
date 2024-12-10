import aiofiles


async def save_file(content: bytes, filename: str) -> str:
    path = f'static/{filename}'
    async with aiofiles.open(path, 'wb') as f:
        await f.write(content)
        return path

