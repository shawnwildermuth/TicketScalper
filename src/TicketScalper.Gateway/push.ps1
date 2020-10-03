docker build -f .\Dockerfile -t ticketscalpergateway:test ..
docker tag ticketscalpergateway:test shawnwildermuth/ticketscalpergateway:test
docker push shawnwildermuth/ticketscalpergateway:test