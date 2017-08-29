<?php
//https://asbra.net/php-curl-class-snippet-tutorial/

require_once __DIR__ .'/includes/curl-helper.php';
$curl = new cURL(true, false); // follow redirects, don't use cookies

$cidade_nome = 'Belo Horizonte';
$cidade_id = 18;
$dias_qtd = 8;
$perfil = 1;

if (isset($_POST['perfil'])) {
    $perfil = $_POST['perfil'];
    $dias_qtd = $_POST['dias'];
    $cidade_id = $_POST['cidade'];
}

$parametros = array(
    'dias' => $dias_qtd,
    'perfil' => $perfil,
    'idCidade' => $cidade_id
);

$calculadoraResposta = $curl->post('http://quantocustaviajar.com/api/calculadora', $parametros);
$calculadoraDados = json_decode($calculadoraResposta);

$sub_total_trasporte = 0;
$sub_total_hospedagem = 0;
$sub_total_alimentacao = 0;
$sub_total_atracoes = 0;
$sub_total_total = 0;

?>

<!-- INICIO CALCULADORA-->
<div class="calculadora">
    <div class="calculadoracontent">
        <a name="calculadora"></a>

        <form method="post" action="">

            <h2>Calcule quanto irá gastar em sua viagem para <select id="cidade" name="cidade">
                    <option value="160" selected="selected">Rio de Janeiro</option>
                    <option value="164">Florianópolis</option>
                    <option value="178">Foz do Iguaçu</option>
                    <option value="161">São Paulo</option>
                    <option value="162">Gramado</option>
                    <option value="173">Natal</option>
                    <option value="179">Porto Seguro</option>
                    <option value="276">Caldas Novas</option>
                    <option value="163">Fortaleza</option>
                </select></h2>

            <div class="filtrocalc">
                <input type="hidden" name="idCidade" id="idCidade" value="<?= $cidade_id ?>">
                <fieldset>
                    <label for="perfil"><strong>Pretendo fazer uma viagem</strong> &nbsp;&nbsp;</label>
                    <select id="perfil" name="perfil">
                        <option value="1" selected="selected">Baixo custo (Mochileiro)</option>
                        <option value="2">Econômico</option>
                        <option value="3">Conforto</option>
                    </select>
                    &nbsp;&nbsp;
                    <a href="/img/tipos-de-perfil.png" data-lightbox="image-1" data-title="Tipos de Perfil"
                       style="color: #909090;">(Veja aqui qual é o seu Perfil)
                    </a>&nbsp;&nbsp;
                    <label for="duas">&nbsp;&nbsp;
                        <strong>e vou ficar&nbsp;&nbsp;</strong>
                    </label>
                    <input type="text" placeholder="<?= $dias_qtd ?>" name="dias" id="dias"
                           value="<?= $dias_qtd ?>"> dias
                    &nbsp;&nbsp;
                    <div id="setcookie" style="float:right;padding-right:20px">
                        <button type="submit" class="pure-button pure-button-primary">
                            Calcular valor total
                        </button>
                    </div>
                </fieldset>

            </div>
        </form>

        <table class="pure-table" align="center">
            <thead>
            <tr>
                <th></th>
                <th>HOSPEDAGEM<!--<img src="/img/calc1.png" width="35" height="35">--></th>
                <th>ALIMENTAÇÃO<!--<img src="/img/calc2.png" width="35" height="35">--></th>
                <th>TRANSPORTE<!--<img src="/img/calc3.png" width="35" height="35">--></th>
                <th>ATRAÇÕES<!--<img src="/img/calc4.png" width="35" height="35">--></th>
                <th>TOTAL POR DIA</th>
            </tr>
            </thead>
            <tbody class="dados-calculadora">

            <?php

            $indice = 1;

            foreach ($calculadoraDados->dados->dia as $obj) {

                $sub_total_trasporte += $obj->trasporte;
                $sub_total_hospedagem += $obj->hospedagem;
                $sub_total_alimentacao += $obj->alimentacao;
                $sub_total_atracoes += $obj->atracoes;
                $sub_total_total += $obj->total_dia;

                ?>
                <tr class="pure-table-odd">
                    <td>DIA <?= $indice ?></td>
                    <td><strong>R$</strong> <?= $obj->hospedagem ?></td>
                    <td><strong>R$</strong> <?= $obj->alimentacao ?></td>
                    <td><strong>R$</strong> <?= $obj->trasporte ?></td>
                    <td><strong>R$</strong> <?= $obj->atracoes ?></td>
                    <td><strong>R$</strong> <?= $obj->total_dia ?></td>
                </tr>
                <?php
                $indice += 1;
            }
            ?>

            </tbody>
            <thead class="dados-calculadora-total">
            <tr class="pure-table-odd">
                <th><strong>SUB-TOTAL:</strong></th>
                <th><strong><?= $sub_total_hospedagem ?></strong></th>
                <th><strong><?= $sub_total_alimentacao ?></strong></th>
                <th><strong><?= $sub_total_trasporte ?></strong></th>
                <th><strong><?= $sub_total_atracoes ?></strong></th>
                <th><strong><?= $sub_total_total ?></strong></th>
            </tr>
            </thead>
        </table>

        <div class="totalcusto">
            <div style="float:left;">
                <a href="/img/tipos-de-perfil.png" data-lightbox="image-3" data-title="Tipos de Perfil">
                    <img id="imagemperfil" src="/img/perfil-mochileiro.png">
                </a>
            </div>
            <div style="float:left; width:700px;">
                <div style="float:left; padding-left: 45px; width:600px; padding-bottom: 20px;">
                        <span style="font-size: 17px; color: #505050;">Sua viagem de <span
                                id="total-dias"><?= $dias_qtd ?></span> dias para <?= $cidade_nome ?>
                            irá custar:
                        </span>
                    <br>
                </div>
                <div style="float:left; padding-left: 45px;">
                    <span style="font-size: 14px; color: #808080;">PASSAGEM AÉREA</span>
                    <br>

                    <div style="display:none" class="custo-aerea">179</div>
                    <span style="font-size: 30px;"><strong
                            id="total-aerea"><?= $calculadoraDados->dados->aerea ?></strong></span>
                </div>
                <div style="float:left; width:20px; padding-left:20px; padding-right:20px; padding-top:21px;">
                    <span style="font-size: 30px;"><strong>+</strong></span>
                </div>
                <div style="float:left;">
                    <span style="font-size: 14px; color: #808080;">CUSTOS</span><br>
                    <span style="font-size: 30px;"><strong
                            id="total-custos"><?= $calculadoraDados->dados->custo ?></strong></span>
                </div>
                <div style="float:left; width:20px; padding-left:20px; padding-right:20px; padding-top:21px;">
                    <span style="font-size: 30px;"><strong>=</strong></span>
                </div>
                <div style="float:left;">
                    <span style="font-size: 14px; color: #808080;">TOTAL</span><br>
                    <span style="font-size: 30px;"><strong
                            id="total-geral"><?= $calculadoraDados->dados->geral ?></strong></span>
                </div>
                <div style="float:left; width:560px; padding-left:45px; padding-top:18px;">
                        <span style="font-size: 14px; color: #808080;">Obs: Valor médio por pessoa. Saiba mais
                            <a href="/img/tipos-de-perfil.png" data-lightbox="image-1" data-title="Tipos de Perfil"
                               style="color: #000;">sobre os diferentes tipo de Perfil aqui
                            </a>.
                        </span>
                    <br>
                </div>
            </div>
        </div>
    </div>
</div>
<!--        FIM CALCULADORA-->