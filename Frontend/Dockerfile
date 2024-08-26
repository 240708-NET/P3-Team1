# FROM node:alpine AS build
# WORKDIR /app
# COPY ./ ./
# RUN npm ci
# ENTRYPOINT [ "npm", "run", "build" ] 
# EXPOSE 80

FROM node:18-alpine

WORKDIR /app

COPY package.json .

RUN npm install

RUN npm i -g serve

COPY . .

RUN npm run build

EXPOSE 3000

CMD [ "serve", "-s", "dist" ]