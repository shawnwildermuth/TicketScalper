docker build -f .\Dockerfile -t ticketscalperweb:test ..
docker tag ticketscalperweb:test shawnwildermuth/ticketscalperweb:test
docker push shawnwildermuth/ticketscalperweb:test