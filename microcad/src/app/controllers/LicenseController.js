///////////////////////////////////////////////////////////////////////////////////////////

import { Op, col } from 'sequelize';

import jwt from "jsonwebtoken";

import TBLDadosdat     from '../models/TBLDadosdat';
import TBLDadosdatmail from '../models/TBLDadosdatmail';
import TBLDadosdth     from '../models/TBLDadosdth';
import TBLDadosins     from '../models/TBLDadosins';
import TBLDadosins000  from '../models/TBLDadosins000';
import TBLDadostxt     from '../models/TBLDadostxt';
import TBLAtualiza     from '../models/TBLAtualiza';
import TBLNaoreg       from '../models/TBLNaoreg';
import TBLRegistro     from '../models/TBLRegistro';
import TBLRegistronet  from '../models/TBLRegistronet';
import TBLXemail       from '../models/TBLXemail';

class LicenseController {
   async dadosdth(req, res) {
      return res.json(await TBLDadosdth.findAll());
   }

   async dadosins000(req, res) {
      return res.json(await TBLDadosins000.findAll({
         order: [
            [ col('totd'), 'DESC']
         ]
      }))
   }

   async dadostxt(req, res) {
      return res.json(await TBLDadostxt.findAll({
         order: [
            [ col('ntot'), 'DESC']
         ]
      }))
   }

   async naoreg(req, res) {
      return res.json(await TBLNaoreg.findAll());
   }

   async registro(req, res) {
      return res.json(await TBLRegistro.findAll());
   }

   async registronet(req, res) {
      return res.json(await TBLRegistronet.findAll());
   }

   async xemail(req, res) {
      return res.json(await TBLXemail.findAll())
   }

   async listEmails(req, res) {
      return res.json(await TBLXemail.findAll({
         where: { 
            nserie: {
               [Op.ne]: 'XXXXXXX'
            }
         }
      }))
   }

   async updateEmails(req, res) {
      const { emails } = req.body

      if (!!emails) {

         emails.forEach(async item => {

            const { id, nserie, email, data } = item;
            
            const emailsExists = await TBLXemail.findOne({where: { email: email }})

            if (emailsExists) {
               await TBLXemail.update({ nserie, email, data }, { where: { email: email } });
            }
            else {
               await TBLXemail.create({ nserie: nserie, email: email, data: data });
            }
         })

         return res.json(emails);
      }

      return res.json([]);
   }
   //
   //MICROCAD
   async microcad(req, res) {
      const {nserie, uname, cname } = req.query
      console.log(nserie, uname, cname)
      const licences =
      [
         {nserie: 'REGV01',uname: 'FELIX'     ,cname: '5-FELIX'},
         {nserie: 'REGV01',uname: 'FELIX'     ,cname: 'FELIX-PC1'},
         {nserie: 'REGV01',uname: 'FELIX'     ,cname: 'FELIX-PC2'},
         {nserie: 'REGV01',uname: 'PLOTAGEM 4',cname: '4-PLOTAGEM'},
         {nserie: 'REGV01',uname: 'ROGERIO BATISTA'   ,cname: 'DESKTOP-J5RQF1S'}
      ]
      const valid = licences.some(x => x.nserie == nserie && x.uname == uname && x.cname == cname)
      return res.json({ valid: valid })
   }
   //
   // CONSULTA REGISTRONET
   async conregistronet(req, res) {
      const { id } = req.params;
      const registro = await TBLRegistronet.findByPk(id);
      if (registro) {
         return res.json(registro);
      }
      return res.json({});
   }
   // CONSULTA REGISTRONET ULTIMO
   async conregistronetultimo(req, res) {
      const registro = await TBLRegistronet.findOne({
         order: [ [ 'nserie', 'DESC' ]]
      });
      if (registro) {
         return res.json(registro);
      }
      return res.json({});
   }
   // UPD REGISTRONET
   async updregistronet(req, res) {
      const {nserie,nome,nomereg,programa,tipo,versao,nserieant,versaoant,serial,dataenv,data,valor,desconto,frete,pago,codrastre,rua,bairro,cidade,uf,cep,cgc,telefone,email,emailcc,obs,} = req.body;
      const registro = await TBLRegistronet.findByPk(nserie);
      if (registro) {
         await TBLRegistronet.update(
            {
               nserie,
               nome,
               nomereg,
               programa,
               tipo,
               versao,
               nserieant,
               versaoant,
               serial,
               dataenv,
               data,
               valor,
               desconto,
               frete,
               pago,
               codrastre,
               rua,
               bairro,
               cidade,
               uf,
               cep,
               cgc,
               telefone,
               email,
               emailcc,
               obs,
            },
            { where: { nserie } }
         );
         return res.json(registro);
      }

      const addRecord = await TBLRegistronet.create({
         nserie,
         nome,
         nomereg,
         programa,
         tipo,
         versao,
         nserieant,
         versaoant,
         serial,
         dataenv,
         data,
         valor,
         desconto,
         frete,
         pago,
         codrastre,
         rua,
         bairro,
         cidade,
         uf,
         cep,
         cgc,
         telefone,
         email,
         emailcc,
         obs,
      });
      return res.json(addRecord);
   }
   // DELETA REGSITRONET
   async delregistronet(req, res) {
      const { id } = req.params;
      const sucess = await TBLRegistronet.destroy({ where: { nserie: id } });
      return res.json(sucess);
   }
   //LISTA REGISTRONET
   async lisregistronet(req, res) {
      const { id1, id2 } = req.params;
      // id1 = 'nserie' ou 'nome' ou 'email' será a coluna de pesquisa
      // id2 = o que foi digitado
      const registros = await TBLRegistronet.findAll({
         where: {
                  [Op.or]: [
                     { [`${id1}`]: { [Op.like]: `%${id2}%` } },
                  ],
         },
         order: [
            [ col(id1), 'ASC']
         ]
      });

      if (registros) {
         return res.json(registros);
      }

      return res.json({});
   }
   //
   // CONSULTA REGISTRO
   async conregistro(req, res) {
      const { id } = req.params;
      const registro = await TBLRegistro.findByPk(id);
      if (registro) {
         return res.json(registro);
      }
      return res.json({});
   }
   // UPD REGISTRO
   async updregistro(req, res) {
      const { nserie, tipo, versao, cliente, uf, cgc, email, serial, verant } = req.body;
      const registro = await TBLRegistro.findByPk(nserie);
      if (registro) {
         await TBLRegistro.update(
            {
               nserie,
               tipo,
               versao,
               cliente,
               uf,
               cgc,
               email,
               serial,
               verant,
            },
            { where: { nserie } }
         );
         return res.json({ nserie, tipo, versao, cliente, uf, cgc, email, serial, verant });
      }

      const addRecord = await TBLRegistro.create({
         nserie,
         tipo,
         versao,
         cliente,
         uf,
         cgc,
         email,
         serial,
         verant,
      });
      return res.json(addRecord);
   }
   // DELETA REGSITRO
   async delregistro(req, res) {
      const { id } = req.params;
      const sucess = await TBLRegistro.destroy({ where: { nserie: id } });
      return res.json(sucess);
   }
   // CONSULTA REGISTRO TESTE
   async teste(req, res) {
      const { id } = req.params;
      const registro = await TBLRegistro.findByPk(id);
      if (registro) {
         return res.json("ENCONTRADO");
      }
      return res.json("*** NÃO ENCONTRADO ***");
   }
   // CONSULTA REGISTRO TESTE COM TOKEN
   async testex(req, res) {
      const { id } = req.params;
      const registro = await TBLRegistro.findByPk(id);
      if (registro) {
         return res.json("ENCONTRADO");
      }
      return res.json("*** NÃO ENCONTRADO ***");
   }
   //
    // LOGIN
   async login(req, res) {
      const {login,pass}=req.body;
      if (!!login && !!pass && login == 'testefixo' && pass == "87654321")
      {
         const token=jwt.sign({login:login,pass:pass},'12345678')
         return  res.json({token:token});
      }
      return res.sendStatus(400);
   }
   //

   //DADOSDAT
   async upddat(req, res) {
      const {nvxx,ndata} = req.body;
      const ndata4 = ndata.substring(0, 4);
      const registro = await TBLDadosdat.findOne({
         where: {
            nvxx: nvxx,
            ndata: ndata4
         }
       });

      if (registro) {
         registro.ntot = registro.ntot + 1;
         await TBLDadosdat.update({
            ntot: registro.ntot
         },
            { where: { id: registro.id} }
         );
         return res.json(registro);
      }
      const addRecord = await TBLDadosdat.create({
         nvxx: nvxx,
         ndata: ndata4,
         ntot: +1,
      });
      return res.json(addRecord);
   }
   //DADOSDATMAIL
   async incdatmail(req, res) {
      const { id1, id2, id3 } = req.params; // nmail, ndata, nhora
      const registro = await TBLDadosdatmail.findByPk(id1);
      if (registro) {
         return res.json({ id1});
      }
      const addRecord = await TBLDadosdatmail.create({
         nmail: id1,
         ndata: id2,
         nhora: id3,
      });
      return res.json(addRecord);
   }
   //
   //DADOSDTH
   async upddth(req, res) {
      const { id1, id2, id3, id4, id5 } = req.params; // nserie0, cname, uname, ndata, nhora
      const registro = await TBLDadosdth.findByPk(id1);
      if (registro) {
         await TBLDadosdth.update(
            {
               nserie0: registro.nserie0,
               uname: id2,
               cname: id3,
               ndata: id4,
               nhora: id5,
            },
            { where: { nserie0: id1 } }
         );
         return res.json(registro);
      }
      const addRecord = await TBLDadosdth.create({
         nserie0: id1,
         uname: id2,
         cname: id3,
         ndata: id4,
         nhora: id5,
      });
      return res.json(addRecord);
   }
   //
   //DADOSINS
   async updins(req, res) {
      const {nserie0,uname,cname,ndata,nhora,chave} = req.body;
      const registro = await TBLDadosins.findOne({
         where: {
            nserie0: nserie0,
            uname: uname,
            cname: cname
         }
      });
      if (registro) {
         registro.udata = ndata;
         registro.uhora = nhora;
         await TBLDadosins.update({
            udata: ndata,
            uhora: nhora,
            chave: chave,
         },
            { where: { id: registro.id} }
         );
         return res.json(registro);
      }
      const addRecord = await TBLDadosins.create({
         nserie0: nserie0,
         uname: uname,
         cname: cname,
         ndata: ndata,
         nhora: nhora,
         udata: ndata,
         uhora: nhora,
         chave: chave,
      });
      return res.json(addRecord);
   }
   //LISTA DADOSINS
   async lisins(req, res) {
      const { id1 } = req.params; //nserie0
      const registros = await TBLDadosins.findAll({
         where: { nserie0: id1 }
      });

      if (registros) {
         return res.json(registros);
      }
      return res.json({});
   }
   //DELETA DADOSINS
   async delins(req, res) {
      const {nserie0, uname,cname} = req.body; // nserie0, uname, cname
      const sucess = await TBLDadosins.destroy({ where: {nserie0: nserie0, uname: uname, cname: cname} });
      return res.json(sucess);
   }
   //
   //TOTAL DADOSINS
   async totins(req, res) {
      const { id1 } = req.params; //nserie0
      const totregistros = await TBLDadosins.count({ where: { nserie0: id1 } });
      return res.json(totregistros);
   }
   //DADOSINS000
   async updins000(req, res) {
      const {nvxx,uname,cname,ndata,nhora} = req.body;
      const registro = await TBLDadosins000.findOne({ where: {nvxx: nvxx, uname: uname, cname: cname} });

      //return res.json(registro)

      if (registro) {
         registro.udata = ndata;
         registro.uhora = nhora;

         const idata = registro.ndata;
         const ihora = registro.nhora;
         const idataFormatada = `${idata.substring(2,4)}/${idata.substring(4,6)}/${idata.substring(0,2)}`
         const ihoraFormatada = `${ihora.substring(0,2)}:${ihora.substring(2,4)}:${ihora.substring(4,6)}`
         const idatacompleta = new Date(`${idataFormatada} ${ihoraFormatada}`)
         //console.log(idatacompleta + " <<< IDATA COMPLETA");

         const udata = ndata;
         const uhora = nhora;
         const udataFormatada = `${udata.substring(2,4)}/${udata.substring(4,6)}/${udata.substring(0,2)}`
         const uhoraFormatada = `${uhora.substring(0,2)}:${uhora.substring(2,4)}:${uhora.substring(4,6)}`
         const udatacompleta = new Date(`${udataFormatada} ${uhoraFormatada}`)
         //console.log(udatacompleta + " <<< UDATA COMPLETA");

         const diffTime = Math.abs(udatacompleta - idatacompleta);
         const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24));

         //return res.json({days:diffDays});

         //console.log(diffTime + " milliseconds");
         //console.log(diffDays + " = total de dias");

         registro.totd = diffDays;

         if (diffDays > 60) {
            const tempoDeEsperaEmMiliSegundos = 10000; //10seg
            await new Promise(resolve => setTimeout(resolve, tempoDeEsperaEmMiliSegundos));
         }

         await TBLDadosins000.update({
            udata: ndata,
            uhora: nhora,
            totd: diffDays,
            exe: '-',
            },
            { where: { id: registro.id} }
         );
         return res.json(registro);
      }
      const addRecord = await TBLDadosins000.create({
         nvxx: nvxx,
         uname: uname,
         cname: cname,
         ndata: ndata,
         nhora: nhora,
         udata: ndata,
         uhora: nhora,
         exe: '-',
      });
      return res.json(addRecord);
   }
   //DADOSINS000X
   async updins000X(req, res) {
      const {nvxx,uname,cname,ndata,nhora} = req.body;
      const registro = await TBLDadosins000.findOne({ where: {nvxx: nvxx, uname: uname, cname: cname} });
      if (registro) {
         registro.udata = ndata;
         registro.uhora = nhora;

         const idata = registro.ndata;
         const ihora = registro.nhora;
         const idataFormatada = `${idata.substring(2,4)}/${idata.substring(4,6)}/${idata.substring(0,2)}`
         const ihoraFormatada = `${ihora.substring(0,2)}:${ihora.substring(2,4)}:${ihora.substring(4,6)}`
         const idatacompleta = new Date(`${idataFormatada} ${ihoraFormatada}`)
         //console.log(idatacompleta + " <<< IDATA COMPLETA");

         const udata = ndata;
         const uhora = nhora;
         const udataFormatada = `${udata.substring(2,4)}/${udata.substring(4,6)}/${udata.substring(0,2)}`
         const uhoraFormatada = `${uhora.substring(0,2)}:${uhora.substring(2,4)}:${uhora.substring(4,6)}`
         const udatacompleta = new Date(`${udataFormatada} ${uhoraFormatada}`)
         //console.log(udatacompleta + " <<< UDATA COMPLETA");

         const diffTime = Math.abs(udatacompleta - idatacompleta);
         const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24));
         //console.log(diffTime + " milliseconds");
         //console.log(diffDays + " days");

         registro.totd = diffDays;

         await TBLDadosins000.update({
            udata: ndata,
            uhora: nhora,
            totd: diffDays,
            exe: 'X',
            },
            { where: { id: registro.id} }
         );
         return res.json(registro);
      }
      const addRecord = await TBLDadosins000.create({
         nvxx: nvxx,
         uname: uname,
         cname: cname,
         ndata: ndata,
         nhora: nhora,
         udata: ndata,
         uhora: nhora,
         exe: 'X',
      });
      return res.json(addRecord);
   }
   //
   //DADOSTXT
   async updtxt(req, res) {
      const { id1, id2, id3 } = req.params; //ncmd, ntot, ndata
      const registro = await TBLDadostxt.findByPk(id1);
      if (registro) {
         const ntot = registro.ntot + +id2;
         await TBLDadostxt.update(
            {
               ncmd: registro.ncmd,
               ntot: registro.ntot + +id2,
               ndata: registro.ndata,
            },
            { where: { ncmd: id1 } }
         );
         return res.json(registro);
      }

      const addRecord = await TBLDadostxt.create({
         ncmd: id1,
         ntot: +id2,
         ndata: id3,
      });
      return res.json(addRecord);
   }

   //CONSULTA ATUALIZAÇÕES
   async conatu(req, res) {
      const { id1 } = req.params; //nvxx
      const registro = await TBLAtualiza.findByPk(id1);
      if (registro) {
         return res.json(registro);
      }
      return res.json({});
   }
   //
      //NAOREG
      async updnreg(req, res) {
         const {nserie0,uname,cname,ndata,nhora,ntipo} = req.body;
         const addRecord = await TBLNaoreg.create({
            nserie0: nserie0,
            uname: uname,
            cname: cname,
            ndata: ndata,
            nhora: nhora,
            ntipo: ntipo,
         });
         return res.json(addRecord);
      }
   ////////////////////////////////////////////////////
   ////////////////////////////////////////////////////
   async show(req, res) {
      const { id } = req.params;
      const registro = await TBLRegistro.findByPk(id);
      if (registro) {
         return res.json(registro);
      }
      return res.json({});
   }

   async update(req, res) {
      const { nserie, tipo, versao, email, cliente, cgc } = req.body;
      const registro = await TBLRegistro.findByPk(nserie);
      if (registro) {
         await TBLRegistro.update(
            {
               nserie,
               tipo,
               versao,
               email,
               cliente,
               cgc,
            },
            { where: { nserie } }
         );

         return res.json({ nserie, tipo, versao, email, cliente, cgc });
      }

      const addRecord = await TBLRegistro.create({
         nserie,
         tipo,
         versao,
         email,
         cliente,
         cgc,
      });

      return res.json(addRecord);
   }

   async delete(req, res) {
      const { id } = req.params;
      const sucess = await TBLRegistro.destroy({ where: { nserie: id } });

      return res.json(sucess);
   }

   async index(req, res) {
      const registros = await TBLRegistro.findAll();
      if (registros) {
         return res.json(registros);
      }
      return res.json({});
   }

   async count(req, res) {
      const sucess = await TBLRegistro.count();
      return res.json(sucess);
   }
   //
}

export default new LicenseController();
