# We will use an existing image based on the
# verson 3.10 of Mono.
# This will be automatically retrieved from the Docker Hub.
# Docker Hub is Dockers community repository of pre-built containers
FROM mono:3.12
# Ensure everything is up to date on the machine and install unzip
RUN apt-get -qq update && apt-get -qqy install unzip
# Install ASP.NET vNext and latest K Runtime Environment (KRE)
RUN curl -s https://raw.githubusercontent.com/aspnet/Home/master/kvminstall.sh | sh
RUN bash -c "source /root/.k/kvm/kvm.sh \
      && kvm upgrade "
# "ENV" sets an environment variable which will be set
# whenever the container is started
ENV PATH $PATH:/root/.k/runtimes/kre-mono.1.0.0-beta3/bin/

VOLUME ["/app"]
WORKDIR /app



