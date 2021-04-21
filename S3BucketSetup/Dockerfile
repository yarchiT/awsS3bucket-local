FROM localstack/localstack

ENV SERVICES=s3
ENV DEBUG=1
ENV DATA_DIR="/tmp/localstack/data"
ENV DEFAULT_REGION="eu-west-1"
ENV AWS_ACCESS_KEY_ID="testkey"
ENV AWS_SECRET_ACCESS_KEY="testsecret"

COPY /init /tmp/localstack