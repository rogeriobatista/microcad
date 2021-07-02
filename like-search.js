const Sequelize = require('sequelize');
const Op = Sequelize.Op;
//LISTA REGISTRONET
async function lisregistronet(req, res) {

    const { id1, id2 } = req.params; 

    // id1 = 'nserie' ou 'nome' ou 'email' será a coluna de pesquisa

    // id2 = o que foi digitado

    const registros = await TBLRegistronet.findAll({
        where: {
                [Op.or]: [
                    { nserie: { [Op.like]: `%${id1}%` } },
                    { nome: { [Op.like]: `%${id1}%` } },
                    { email: { [Op.like]: `%${id1}%` } }
                ],
        } //<<<<<<<<<<<<<< esta linha é a pesquisa conforme o id1
    });

    if (registros) {
        return res.json(registros);
    }

    return res.json({});
}
