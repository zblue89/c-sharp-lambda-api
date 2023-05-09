#!/bin/sh

awslocal cloudformation create-stack --stack-name todo-dynamodb-stack --template-body file:///etc/localstack/cfn/dynamodb.yml
awslocal cloudformation wait stack-create-complete --stack-name todo-dynamodb-stack

exit 0