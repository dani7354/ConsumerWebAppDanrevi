!#/bin/bash
docker swarm init
docker stack deploy -c docker_compose.yml

# Restore db
docker exec -i 56996b879bca sh -c 'exec mysql -uroot -p"$MYSQL_ROOT_PASSWORD"' < ./db_export.sql
