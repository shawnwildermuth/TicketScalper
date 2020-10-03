docker build -f .\Dockerfile -t ticketscalpersales:test ..
docker tag ticketscalpersales:test shawnwildermuth/ticketscalpersales:test
docker push shawnwildermuth/ticketscalpersales:test