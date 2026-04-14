Pré-requisitos:

- Ter o Docker instalaado na maquina.

Passo a passo para instalação

- clonar o repositorio
- acessar o path que contem o Dockerfile dentro  da solucao via linha de comando e rodar o comando docker build -t user-api .

Como executar a aplicação localmente

- Após o build da imagem rodar o comando docker run -d -p 8080:80 user-api


Como testar os endpoints

- Os endpoints estarão disponiveis via swagger no path localhost:8080/swagger

