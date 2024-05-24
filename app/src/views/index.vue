<template>
    <div id="browser">
        <input id="search" placeholder="Search.."/>
        <div id="shops">
            <ShopCard v-for="shop in shops" :shop="shop"/>
        </div>
    </div>
</template>

<script lang="ts" setup>
import ShopCard from '@/components/ShopCard.vue';
import ShopService from '@/application/services/ShopService';
import Shop from '@/application/models/Shop';
import { Ref } from 'vue';

const service = new ShopService();
const shops = service.shops;
</script>

<style lang="scss" scoped>
    $searchPlaceholderColor: #FFDCCC; 

    #browser
    {
        display: flex;
        flex-direction: column;
        max-height: 100vh;
        overflow: hidden;
    }

    #search
    {
        border: none;
        background: none;
        box-shadow: none;
        outline: none;
        color: inherit;
        font-size: inherit;
        font-family: inherit;
        padding: 0;
        margin: 0;

        padding: 20px;
        background: #27232F;
        color: $searchPlaceholderColor;
        font-family: "Lato", sans-serif;
        font-weight: 400;
        font-style: normal;
        font-size: 20px;
    }

    #shops
    {
        display: flex;
        padding: 32px;
        flex-direction: column;
        grid-row-gap: 16px;
        overflow: auto;

        &::-webkit-scrollbar 
        {
            width: 6px;
        }

        &::-webkit-scrollbar-track 
        {
            background: rgba(0, 0, 0, 0);
        }

        &::-webkit-scrollbar-thumb 
        {
            background: #3A3446;
        }

        &::-webkit-scrollbar-thumb:hover 
        {
            background: #3A3446;
        }
    }
</style>