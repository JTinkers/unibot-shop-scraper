<template>
    <div class="shop-card">
        <div class="shop">
            <span class='shop-name' v-text="shop.name"/>
            <span class='shop-position' v-text="position"/>
            <span class='shop-owner' v-text="owner"/>
        </div>
        <div class="items">
            <div class="item" v-for="{ id, name, quantity, price, value } in items">
                <span class="item-id" v-text="'#️⃣' + id"/>
                <span class="item-name" v-text="'📋' + name"/>
                <span class="item-quantity" v-text="'🔢' + quantity"/>
                <span class="item-price" v-text="'🏷️' + price"/>
                <span class="item-value" v-text="'💰' + value"/>
            </div>
        </div>
    </div>
</template>

<script lang="ts" setup>
import Shop from '@/application/models/Shop';
import { PropType, computed } from 'vue';

const props = defineProps(
{
    shop: 
    {
        type: Object as PropType<Shop>,
        required: true
    }
})

const items = computed(() => props.shop.items);
const owner = computed(() => props.shop.owner.name);
const position = computed(() => `X: ${props.shop.position.x} | Y: ${props.shop.position.y}`)
</script>

<style lang="scss" scoped>
    .shop-card
    {
        display: flex;
        flex-direction: column;
        background: #131117;
        border-radius: 5px;
        font-family: "Lato", sans-serif;
        border: 1px solid #27232F;
    }

    .shop
    {
        display: flex;
        padding: 16px;
        padding-bottom: 8px;
    }

    .shop-name
    {
        font-family: "Lato", sans-serif;
        font-weight: 700;
        font-style: normal;
        font-size: 20px;
        color: #FCB1A6;
    }

    .shop-position
    {
        margin-left: auto;
    }

    .shop-owner
    {
        margin-left: 32px;
    }

    .items
    {
        display: flex;
        flex-direction: column;
        padding: 16px;
        padding-top: 8px;
    }

    .item
    {
        display: grid;
        grid-column-gap: 16px;
        align-items: flex-start;
        align-content: flex-start;
        justify-content: flex-start;
        grid-template-columns: min-content 1fr min-content min-content min-content;
        text-wrap: nowrap;
    }

    .item-name
    {
        justify-self: flex-start;
    }
</style>