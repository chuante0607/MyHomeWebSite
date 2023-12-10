<script setup>
import TheLayout from './components/TheLayout.vue'
import { ref } from 'vue'
const count = ref(100)
</script>

<template>
	<div class="father">
		<h2>父組件App</h2>
		<TheLayout
			:count="count"
			message="father message" />
	</div>
</template>

<style scoped></style>
