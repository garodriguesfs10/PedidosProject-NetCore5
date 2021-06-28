import React, { useState } from 'react'
import { Container } from 'react-bootstrap'
import { format, parseISO } from 'date-fns'
const Relatorio = ({ numero, relatorio }) => {



    function renderSwitch(numero) {
        switch (numero) {
            case 1:
                return (<Container> <p>Ranking de Produtos mais vendidos: </p>{relatorio.map((e, i) => (
                    <>
                        {i + 1} - {e.nome} - vendido {e.qtd} vezes, no total de R$ {e.valorTotal} reais
                        <br></br>
                    </>
                ))}</Container>);
            case 2:
                return (<Container> <p>Cidades com mais vendas: </p>{relatorio.map((e, i) => (
                    <>
                        {i + 1} - {e.nomeCidade} teve {e.qtd} vendas, no total de R$ {e.valorTotal} reais
                        <br></br>
                    </>
                ))}</Container>);
            case 3:
                return (<Container> <p>Vendas agrupadas por faixa etária: </p>{relatorio.map((e, i) => (
                    <>
                        {i + 1} - Na faixa etária de {e.faixaetaria} teve {e.quantidade} vendas, no total de R$ {e.valorTotal} reais
                        <br></br>
                    </>
                ))}</Container>);
            case 4:
                return (<Container> <p>Vendas agrupadas por faixa etária: </p>{relatorio.map((e, i) => (
                    <>
                        {i + 1} - Data: {e.dataCriacao ? format(parseISO(e.dataCriacao), "dd/MM/yyyy") : ""} - Método: <strong>{e.nome}</strong> - Total de R$ {e.valorTotal} reais
                        <br></br>
                    </>
                ))}</Container>);
            default:
                return 'Erro :(';
        }
    }


    return (
        <>
            {renderSwitch(numero)}
        </>
    )

}

export default Relatorio