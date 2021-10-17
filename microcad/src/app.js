import 'dotenv/config';

import express from 'express';
// import path from 'path';
// import cors from 'cors';
import Youch from 'youch';
import 'express-async-errors';
import routes from './routes';

import './database';

class App {
   constructor() {
      this.server = express();
      this.server.use(express.json({limit: '50mb'}));
      //this.server.use(express.json());

      // this.middlewares();

      //
      this.routes();

      // this.exceptionHandler();
   }

   middlewares() {
      // this.server.use(Sentry.Handlers.requestHandler());
      // this.server.use(cors({ origin: 'http://192.168.0.10' }));
      // this.server.use(cors());
      // this.server.use(express.json());
      // this.server.use(
      //    '/files',
      //    // express.static(path.resolve(__dirname, '..', 'tmp', 'uploads'))
      //    express.static(path.resolve(__dirname, '..', 'tmp'))
      // );
   }

   routes() {
      this.server.use(routes);
      // this.server.use(Sentry.Handlers.errorHandler());
   }

   exceptionHandler() {
      this.server.use(async (err, req, res, next) => {
         if (process.env.NODE_ENV === 'development') {
            const errors = await new Youch(err, req).toJSON();
            return res.status(500).json(errors);
         }
         return res.status(500).json({ error: 'Internal server error' });
      });
   }
}

export default new App().server;
