CREATE DATABASE umbracodb ;
CREATE USER umbraco IDENTIFIED BY 'fDP1weZqgdlM';
GRANT ALL ON umbracodb.* TO umbraco;
show grants for umbraco;
