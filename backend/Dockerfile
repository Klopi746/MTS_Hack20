FROM python:3.12

WORKDIR /backend

RUN mkdir -p static

COPY ./requirements.txt ./requirements.txt

RUN pip install -r requirements.txt

COPY . .

CMD ["python", "-m", "uvicorn", "main:app", "--host", "0.0.0.0"]