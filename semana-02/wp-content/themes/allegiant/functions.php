<?php if (!isset($content_width)) $content_width = 640;
define('CPOTHEME_ID', 'allegiant');
define('CPOTHEME_NAME', 'Allegiant');
define('CPOTHEME_VERSION', '1.0.8');
//Other constants
define('CPOTHEME_LOGO_WIDTH', '215');
define('CPOTHEME_USE_SLIDES', true);
define('CPOTHEME_USE_FEATURES', true);
define('CPOTHEME_USE_PORTFOLIO', true);
define('CPOTHEME_USE_SERVICES', true);
define('CPOTHEME_USE_TESTIMONIALS', true);
define('CPOTHEME_USE_TEAM', true);
define('CPOTHEME_USE_CLIENTS', true);
define('CPOTHEME_PREMIUM_NAME', 'Allegiant Pro');
define('CPOTHEME_PREMIUM_URL', '//www.cpothemes.com/theme/allegiant');

//Load Core; check existing core or load development core
$core_path = get_template_directory() . '/core/';
if (defined('CPOTHEME_CORELITE')) $core_path = CPOTHEME_CORELITE;
require_once $core_path . 'init.php';

$include_path = get_template_directory() . '/includes/';

//Main components
require_once($include_path . 'setup.php');

remove_action('woocommerce_before_shop_loop', 'woocommerce_result_count', 20);
remove_action('woocommerce_before_shop_loop', 'woocommerce_catalog_ordering', 30);

add_filter('woocommerce_product_tabs', function ($tabs) {
    return [];
}, 98);

add_action('init', function () {
    remove_action('woocommerce_single_product_summary', 'woocommerce_template_single_price', 10);
    remove_action('woocommerce_single_product_summary', 'woocommerce_template_single_excerpt', 20);
    add_action('woocommerce_single_product_summary', 'woocommerce_template_single_excerpt', 10);
    add_action('woocommerce_single_product_summary', 'woocommerce_template_single_price', 20);
});

add_filter('woocommerce_product_single_add_to_cart_text', function () {
    return __('Embarque', 'woocommerce');
});

add_filter('the_content', function ($content) {
    if (is_singular()) {
        return $content . '<div class="embarque-area"><a class="btn-embarque" href="/shop">Embarque</a></div>';
    }

    return $content;
});

function wc_ninja_remove_password_strength()
{
    if (wp_script_is('wc-password-strength-meter', 'enqueued')) {
        wp_dequeue_script('wc-password-strength-meter');
    }
}

add_action('wp_print_scripts', 'wc_ninja_remove_password_strength', 100);

function woocommerce_template_loop_product_title()
{
    global $post;
    echo '<h3>' . get_the_title() . '</h3>';
    echo '<div class="product-excerpt">' . apply_filters('woocommerce_short_description', $post->post_excerpt) . '</div>';
}

function minha_calculadora()
{
    //  https://asbra.net/php-curl-class-snippet-tutorial/
    //  http://quantocustaviajar.com
    //  TODO
    //      1. carregar imagens das cidades no header
    //          http://quantocustaviajar.com/ckfinder/userfiles/images/rio-de-janeiro.jpg
    //      2. ordernar lista de cidades por ordem alfabética
    //      3. autocomplete para cidades?

    $cidades = array(
        '276' => 'Caldas Novas (GO)',
        '164' => 'Florianópolis (SC)',
        '163' => 'Fortaleza (CE)',
        '178' => 'Foz do Iguaçu (PR)',
        '162' => 'Gramado (RS)',
        '173' => 'Porto Seguro (BA)',
        '160' => 'Rio de Janeiro (RJ)',
        '161' => 'São Paulo (SP)',
        '185' => 'Búzios (RJ)',
        '176' => 'Salvador (BA)',
        '184' => 'Paraty (RJ)',
        '183' => 'Manaus (AM)',
        '181' => 'Bonito (MS)',
        '296' => 'Trancoso (BA)'
    );

    //sort($cidades);

    $perfis = array(
        '1' => array(
            'nome' => 'Baixo custo (Mochileiro)',
            'imagem' => 'perfil-mochileiro.png'),
        '2' => array(
            'nome' => 'Econômico',
            'imagem' => 'perfil-economico.png'),
        '3' => array(
            'nome' => 'Conforto',
            'imagem' => 'perfil-conforto.png')
    );

    //sort($perfis);

    require_once __DIR__ . '/includes/curl-helper.php';
    $curl = new cURL(true, false); // follow redirects, don't use cookies

    $perfil_id = 1;
    $dias_qtd = 8;
    $cidade_id = 160;

    $cidade_nome = $cidades[$cidade_id];

    if (isset($_POST['perfil'])) {
        $perfil_id = $_POST['perfil'];
        $dias_qtd = $_POST['dias'];
        $cidade_id = $_POST['cidade'];
        $cidade_nome = $cidades[$_POST['cidade']];
    }

    $parametros = array(
        'dias' => $dias_qtd,
        'perfil' => $perfil_id,
        'idCidade' => $cidade_id
    );

    $post_result = $curl->post('http://quantocustaviajar.com/api/calculadora', $parametros);
    $calculadora_dados = json_decode($post_result);

    $sub_total_trasporte = 0;
    $sub_total_hospedagem = 0;
    $sub_total_alimentacao = 0;
    $sub_total_atracoes = 0;
    $sub_total_total = 0;

    ob_start();
    ?>

    <div class="calculadora">
        <div class="calculadoracontent">
            <a name="calculadora"></a>

            <form method="post" action="">

                <h2>Calcule quanto irá gastar em sua viagem para <select id="cidade" name="cidade" style="width: 250px">
                        <?php foreach ($cidades as $key => $value) { ?>
                            <option value="<?= $key ?>"
                                    <?php if ($key == $cidade_id) { ?>selected="selected"<?php } ?>><?= $value ?></option>
                        <?php } ?>
                    </select></h2>

                <div class="filtrocalc">
                    <input type="hidden" name="idCidade" id="idCidade" value="<?= $cidade_id ?>">
                    <fieldset>
                        <label for="perfil"><strong>Pretendo fazer uma viagem</strong> &nbsp;&nbsp;</label>
                        <select id="perfil" name="perfil" style="width: 200px">
                            <?php foreach ($perfis as $key => $value) { ?>
                                <option value="<?= $key ?>"
                                        <?php if ($key == $perfil_id) { ?>selected="selected"<?php } ?>><?= $value['nome'] ?></option>
                            <?php } ?>
                        </select>
                        &nbsp;&nbsp;
                        <a href="<?php echo get_template_directory_uri() . '/images/tipos-de-perfil.png'; ?>"
                           data-lightbox="image-1"
                           data-title="Tipos de Perfil"
                           style="color: #909090;">(Veja aqui qual é o seu Perfil)
                        </a>&nbsp;&nbsp;
                        <label for="duas">&nbsp;&nbsp;
                            <strong>e vou ficar&nbsp;&nbsp;</strong>
                        </label>
                        <input type="text" placeholder="<?= $dias_qtd ?>" name="dias" id="dias"
                               value="<?= $dias_qtd ?>" style="width: 160px"> dias
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

                foreach ($calculadora_dados->dados->dia as $obj) {

                    $sub_total_trasporte += $obj->trasporte;
                    $sub_total_hospedagem += $obj->hospedagem;
                    $sub_total_alimentacao += $obj->alimentacao;
                    $sub_total_atracoes += $obj->atracoes;
                    $sub_total_total += $obj->total_dia;

                    ?>
                    <tr class="pure-table-odd">
                        <td>DIA <?= $indice ?></td>
                        <td><strong>R$ </strong> <?= $obj->hospedagem ?></td>
                        <td><strong>R$ </strong> <?= $obj->alimentacao ?></td>
                        <td><strong>R$ </strong> <?= $obj->trasporte ?></td>
                        <td><strong>R$ </strong> <?= $obj->atracoes ?></td>
                        <td><strong>R$ </strong> <?= $obj->total_dia ?></td>
                    </tr>
                    <?php
                    $indice += 1;
                }
                ?>

                </tbody>
                <thead class="dados-calculadora-total">
                <tr class="pure-table-odd">
                    <th><strong>SUB-TOTAL:</strong></th>
                    <th><strong>R$ <?= $sub_total_hospedagem ?></strong></th>
                    <th><strong>R$ <?= $sub_total_alimentacao ?></strong></th>
                    <th><strong>R$ <?= $sub_total_trasporte ?></strong></th>
                    <th><strong>R$ <?= $sub_total_atracoes ?></strong></th>
                    <th><strong>R$ <?= $sub_total_total ?></strong></th>
                </tr>
                </thead>
            </table>

            <div class="totalcusto">
                <div style="float:left;">
                    <a href="<?php echo get_template_directory_uri() . '/images/tipos-de-perfil.png'; ?>"
                       data-lightbox="image-3" data-title="Tipos de Perfil">
                        <img id="imagemperfil"
                             src="<?php echo get_template_directory_uri() . '/images/' . $perfis[$perfil_id]['imagem']; ?>">
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
                                    id="total-aerea">R$ <?= $calculadora_dados->dados->aerea ?></strong></span>
                    </div>
                    <div style="float:left; width:20px; padding-left:20px; padding-right:20px; padding-top:21px;">
                        <span style="font-size: 30px;"><strong>+</strong></span>
                    </div>
                    <div style="float:left;">
                        <span style="font-size: 14px; color: #808080;">CUSTOS</span><br>
                        <span style="font-size: 30px;"><strong
                                    id="total-custos">R$ <?= $calculadora_dados->dados->custo ?></strong></span>
                    </div>
                    <div style="float:left; width:20px; padding-left:20px; padding-right:20px; padding-top:21px;">
                        <span style="font-size: 30px;"><strong>=</strong></span>
                    </div>
                    <div style="float:left;">
                        <span style="font-size: 14px; color: #808080;">TOTAL</span><br>
                        <span style="font-size: 30px;"><strong
                                    id="total-geral">R$ <?= $calculadora_dados->dados->geral ?></strong></span>
                    </div>
                    <div style="float:left; width:560px; padding-left:45px; padding-top:18px;">
                        <span style="font-size: 14px; color: #808080;">Obs: Valor médio por pessoa. Saiba mais
                            <a href="<?php echo get_template_directory_uri() . '/images/tipos-de-perfil.png'; ?>" data-lightbox="image-1" data-title="Tipos de Perfil"
                               style="color: #000;">sobre os diferentes tipo de Perfil aqui.
                            </a>
                        </span>
                        <br>
                        <span style="font-size: 14px; color: #808080;">
                            <a href="http://quantocustaviajar.com/brasil/" target="_blank"
                               style="color: #000;">Mais detalhes veja em nosso parceiro Quanto Custa Viajar.
                            </a>
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <?php
    return ob_get_clean();
}

add_shortcode('calculadora', 'minha_calculadora');
