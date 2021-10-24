FROM postgres:14
# Runs as root:
RUN apt-get update && apt-get -y upgrade

# Switch to non-root user:
RUN useradd --create-home dbuser
WORKDIR /home/dbuser
USER dbuser

# Runs as non-root user:
ENTRYPOINT ["whoami"]
