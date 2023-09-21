# Stage 1: Build the React application
FROM node:14-alpine as builder

WORKDIR /frontend

ENV PATH /frontend/node_modules/.bin:$PATH

# install app dependencies 
COPY package*.json ./
COPY package-lock.json ./
RUN npm install --silent

# add app
COPY . ./

# Expose the default Nginx port
EXPOSE 3000

# Start container
CMD ["npm", "start"]
