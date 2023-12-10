<script setup>
const props = defineProps({
	message: String,
	count: Number,
})
</script>

<template>
	<div class="son">
		<h3>子組件Son</h3>
		<h1>{{ message }} - {{ count }}</h1>
	</div>
</template>

<style scoped>
.son {
	background-color: aqua;
}
</style>
