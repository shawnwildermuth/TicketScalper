docker build -f .\Dockerfile -t ticketscalperauth:test ..
docker tag ticketscalperauth:test shawnwildermuth/ticketscalperauth:test
docker push shawnwildermuth/ticketscalperauth:test