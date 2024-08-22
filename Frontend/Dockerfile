FROM node:alpine AS build
WORKDIR /app
COPY ./ ./
RUN npm ci
ENTRYPOINT [ "npm", "run", "build" ] 
EXPOSE 80