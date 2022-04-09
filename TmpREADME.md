# Template project
## DockerCompose
Service configuration example to add to environment docker/docker-compose.yaml : 
````yaml
 project_placeholder:
    container_name: project_placeholder
    image: seed-road/project_placeholder
    build:
      context: ../project_placeholder
    restart: unless-stopped
    ports:
      - 5000:5000
      - 5001:5001
    environment:
      ASPNETCORE_URLS: http://+:5000;https://+:5001
      ASPNETCORE_ENVIRONMENT: Development
      ASPNETCORE_Kestrel__Certificates__Default__Path: "/https/project_placeholder.pfx"
      ASPNETCORE_Kestrel__Certificates__Default__Password: "project_placeholder.pwd"
      ConnectionString:TemplateDb: "Server=127.0.0.1,1433;Database=template;User Id=sa;Password=pwd;"
      RabbitMqConfiguration:Host: "seed-road-rabbitmq"
      RabbitMqConfiguration:Port: 15672
      RabbitMqConfiguration:Password: "lapin"
      RabbitMqConfiguration:Username: "lapin"
      RabbitMqConfiguration:TemplateExchange:Name: "app.templates"
      RabbitMqConfiguration:TemplateExchange:OutTemplateActionRouting: "out.action"
      RabbitMqConfiguration:TemplateExchange:InTemplateActionRouting: "in.action"
    networks:
      - seed-road-network
    volumes:
      - ~/.aspnet/https:/https:ro
````
## Docker
Build command : ``docker build . -t seed-road/project_placeholder``  
Run command : 
````
docker run --rm -it -p 5000:5000 -p 5001:5001 \
-e ASPNETCORE_URLS="http://+:5000;https://+:5001" \
-e ASPNETCORE_HTTPS_PORT=5001 \
-e ASPNETCORE_Kestrel__Certificates__Default__Password="project_placeholder.pwd" \
-e ASPNETCORE_Kestrel__Certificates__Default__Path=/https/project_placeholder.pfx \
-v ${HOME}/.aspnet/https:/https/ --name project_placeholder seed-road/project_placeholder
````
