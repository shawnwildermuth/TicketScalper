docker build -f .\Dockerfile -t ticketscalpershows:test ..
docker tag ticketscalpershows:test shawnwildermuth/ticketscalpershows:test
docker push shawnwildermuth/ticketscalpershows:test