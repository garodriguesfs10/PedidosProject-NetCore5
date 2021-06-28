import React, { useState } from 'react'
import Homescreen from './Homescreen'
import { Container, Dropdown } from 'react-bootstrap'
import Relatorio from './Relatorio'
import axios from 'axios'

const Relatorios = () => {

    const [relData, setRelData] = useState([]);
    const [numero, setNumero] = useState(0);
    const [buscando, setBuscando] = useState(false);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(true);

    function isDone(data) {
        if (data) {
            setRelData(data);
            setLoading(false);
            setError(false);
        }
    }

    async function getRelatorio(value) {
        try {
            setBuscando(true);
            setNumero(value);
            switch (value) {
                case 1:
                    var { data } = await axios.get('https://localhost:44303/api/Pedidos/relatorio/produtosmaisvendidos');
                    isDone(data);
                    break;
                case 2:
                    var { data } = await axios.get('https://localhost:44303/api/Pedidos/relatorio/vendasporcidade');
                    isDone(data);
                    break;
                case 3:
                    var { data } = await axios.get('https://localhost:44303/api/Pedidos/relatorio/vendasporfaixaetaria');
                    isDone(data);
                    break;
                case 4:
                    var { data } = await axios.get('https://localhost:44303/api/Pedidos/relatorio/pagamentos');
                    isDone(data);
                    break;
                default:
                    break;
            }


        } catch {
            setLoading(false);
            setError(true);
        }

    }

    return (
        <>
            <Homescreen />
            <Container>


                <Dropdown>
                    <Dropdown.Toggle variant="secondary" id="dropdown-basic">
                        Lista de relatórios disponíveis
                    </Dropdown.Toggle>

                    <Dropdown.Menu>
                        <Dropdown.Item onClick={() => getRelatorio(1)}>Listagem de produtos mais vendidos</Dropdown.Item>
                        <Dropdown.Item onClick={() => getRelatorio(2)}>Totalização de Vendas por Cidade</Dropdown.Item>
                        <Dropdown.Item onClick={() => getRelatorio(3)}>Totalização de Vendas por Faixa Etária</Dropdown.Item>
                        <Dropdown.Item onClick={() => getRelatorio(4)}>Totalização de Formas de Pagamento por Dia</Dropdown.Item>
                    </Dropdown.Menu>
                </Dropdown>

                {!buscando ? "" : loading ? "Carregando" : error ? "Erro ao buscar relatório" : (numero !== 0 && relData) ?
                    <Relatorio numero={numero} relatorio={relData} /> : "Erro desconhecido"
                }


            </Container>
        </>

    )
}



export default Relatorios