import { format } from 'date-fns';
import pt from 'date-fns/locale/pt';
import Mail from '../../lib/Mail';

class PasswordRequest {
   get key() {
      return 'PasswordRequest';
   }

   async handle({ data }) {
      await Mail.sendMail({
         to: `<${data.user.email}>`,
         subject: 'Credencial de acesso goSports',
         template: 'passwordrequest',
         context: {
            email: data.user.email,
            password: data.user.password,
            date: format(new Date(), "dd 'de' MMMM' às '  H:mm' horas'", {
               locale: pt,
            }),
         },
      });
   }
}

export default new PasswordRequest();
