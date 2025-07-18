# Use Cypress base image
FROM cypress/browsers:latest

# Change ownership of .npm folder to non-root user
# RUN chown -R 1001:0 "/.npm"

# Change to a non-root user
# USER 1001

ENV FRONTEND_URL ""

# at build time:
# set the current directory to `/src`
WORKDIR /src 

# copy the manifest file: package.json
COPY package.json /src

# from a shell, run `npm install`
RUN npm install 

# copy the content into place
COPY . /src

# as the container starts:
# `npm run cy:run`
CMD [ "npm", "run", "cy:run" ]
