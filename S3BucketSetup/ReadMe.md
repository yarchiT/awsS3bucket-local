
# How to run localstack container from Dockerfile
docker run -p 4566:4566 --name my-awss3-bucket --env SERVICES=s3 --env DEBUG=1 --env DATA_DIR='/tmp/localstack/data' --env DEFAULT_REGION='eu-west-1' --env AWS_ACCESS_KEY_ID='testkey' --env AWS_SECRET_ACCESS_KEY='testsecret' my-awss3

### add file with metadata to aws bucket
awslocal s3 cp image.jpg s3://my-bucket/Data/1/24391/24391661/image.jpg --content-type "application/x-amz-json-1.0" --metadata '{\"uploaddate\":\"17/03/2021 13:33\", \"note\":\"testNote\", \"status\":\"Waiting\", \"filetype\":\"0\", \"uploadmethod\":\"Manual\"}'

### create bucket
awslocal s3api create-bucket --bucket my-bucket --region eu-west-1

### list buckets
awslocal s3api list-buckets --query "Buckets[].Name"

### create folder
awslocal s3api put-object --bucket my-bucket --key Data/

### copy file
awslocal s3 cp aws.txt s3://my-bucket/Data/aws.txt

### Print files info from folder
awslocal s3 ls s3://my-bucket/Data/ --recursive --human-readable --summarize

### Delete folder
awslocal s3 rm s3://my-bucket/Data/ --recursive

### list file metadata
awslocal s3api head-object --bucket my-bucket --key Data/2/24391/24391661/ID-BackSide-test.png

### Copy all files from this folder
awslocal s3 cp {Folder_with_docs} s3://my-bucket/ --recursive
