from fastapi import APIRouter, UploadFile, File, Query

from src.services.files import save_file

router = APIRouter(
    prefix='/files',
    tags=['Файлы / Асеты']
)


@router.post('', response_model=str)
async def upload_file(file: UploadFile = File(), file_name: str | None = Query(None)):
    content = await file.read()
    filename = file_name or file.filename
    return await save_file(content=content, filename=filename)
