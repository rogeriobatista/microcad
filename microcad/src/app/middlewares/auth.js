import jwt from 'jsonwebtoken';
import { promisify } from 'util';
import authConfig from '../../config/auth';
import User from '../models/User';

export default async (req, res, next) => {
   const authHeader = req.headers.authorization;
   if (!authHeader) {
      return res.status(401).json({ error: 'Auth001 - Token not provided.' });
   }
   const [, token] = authHeader.split(' ');
   try {
      const decoded = await promisify(jwt.verify)(token, authConfig.secret);
      req.userId = decoded.id;

      const isTokenValid = await User.findOne({ where: { id: req.userId } });
      if (!isTokenValid) {
         return res.status(401).json({ error: 'Auth002 - Orphan token.' });
      }
      return next();
   } catch (err) {
      return res.status(401).json({ error: 'Auth003 - Invalid token.' });
   }
};
