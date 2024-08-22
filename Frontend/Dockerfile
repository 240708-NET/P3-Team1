# FROM node:alpine AS build
# WORKDIR /app
# COPY ./ ./
# # gather dependencies and install
# RUN npm install
# # build the app!
# RUN npm run build
# FROM nginx:latest AS RUN

# COPY --from=build /app/dist/* /usr/share/nginx/html

# EXPOSE 80
# EXPOSE 443

FROM node:alpine AS build
WORKDIR /app
COPY ./ ./
RUN npm ci
ENTRYPOINT [ "npm", "run", "build" ] 
EXPOSE 80