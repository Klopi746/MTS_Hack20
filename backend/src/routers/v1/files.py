from fastapi import APIRouter, UploadFile, File, Query
from src.services.files import save_file, get_files_list, delete_file

router = APIRouter(
    prefix='/files',
    tags=['Файлы / Асеты']
)


@router.get('', response_model=list[str])
async def get_uploaded_files():
    return get_files_list()


@router.post('', response_model=str)
async def upload_file(file: UploadFile = File(), file_name: str | None = Query(None)):
    content = await file.read()
    filename = file_name or file.filename
    return await save_file(content=content, filename=filename)


@router.delete('/{file_name}')
async def delete_uploaded_file(file_name: str):
    delete_file(file_name)


