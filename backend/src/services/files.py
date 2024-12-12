from pathlib import Path

import aiofiles


async def save_file(content: bytes, filename: str) -> str:
    path = f'static/{filename}'
    async with aiofiles.open(path, 'wb') as f:
        await f.write(content)
        return path


def get_files_list():
    files = Path('static').glob('**/*')
    return [file.name for file in files]

def delete_file(filename: str):
    try:
        Path(f'static/{filename}').unlink()
    except FileNotFoundError:
        pass

